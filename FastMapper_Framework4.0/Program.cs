using FastMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APIModel = Ctrip.Fin.API.Client;
using DataModel = Ctrip.Fin.API.Data.Model;

namespace FastMapperDemo
{

    class Program
    {
        static void Main(string[] args)
        {

            SingleMdoelCustom_Test();

        }

        /// <summary>
        /// 单个对象的转换，属性必须相同
        /// </summary>
        private static void SingleModel_Test()
        {

            //api的数据源
            APIModel.BalanceRechargeOrderModel apiModel = new APIModel.BalanceRechargeOrderModel();

            apiModel.AccountID = 10;
            apiModel.DataChange_CreateTime = DateTime.Now.AddDays(-10);
            apiModel.IsInvoiced = true;
            //转换成数据层model
            DataModel.BalanceRechargeOrderModel dataModel = TypeAdapter.Adapt<APIModel.BalanceRechargeOrderModel, DataModel.BalanceRechargeOrderModel>(apiModel);
            
            //测试结果
            Console.Write(dataModel.DataChange_CreateTime.Value.ToString("yyyy-MM-dd"));
        }

        /// <summary>
        /// 单个对象，自定义属性对应关系的转换
        /// </summary>
        private static void SingleMdoelCustom_Test()
        {
            //定义配置
            TypeAdapterConfig<APIModel.InvoiceModel, DataModel.AmpOrder.InvoiceEntity>.NewConfig()
                .MapFrom(dest => dest.BID, src => src.UserID.Value.ToString()).MapFrom(dest => dest.GCOrderID, src => src.BalanceRechargeID);

            APIModel.InvoiceModel apiModel = new APIModel.InvoiceModel();
            apiModel.UserID = 33;
            apiModel.OrderID = 44;
            apiModel.BalanceRechargeID = 55;

            //转换成数据层model
            DataModel.AmpOrder.InvoiceEntity dataModel = TypeAdapter.Adapt<APIModel.InvoiceModel, DataModel.AmpOrder.InvoiceEntity>(apiModel);


            //测试结果
            Console.WriteLine(dataModel.BID);
            Console.WriteLine(dataModel.OrderID);
            Console.WriteLine(dataModel.GCOrderID);
        }

        /// <summary>
        /// 列表对象的转换
        /// </summary>
        private static void ListModel_Test()
        {
            //Mapping Lists Included，列表的转换
            Ctrip.Fin.API.Client.AddBalanceRechargeOrderRequestType request = new APIModel.AddBalanceRechargeOrderRequestType();
            request.InvoiceList = new List<APIModel.InvoiceModel>();

            for (int i = 0; i < 10; i++)
            {
                APIModel.InvoiceModel m = new APIModel.InvoiceModel();
                m.BalanceRechargeID = i;
                request.InvoiceList.Add(m);
            }

            List<DataModel.InvoiceModel> lstDataMoel = TypeAdapter.Adapt<List<APIModel.InvoiceModel>, List<DataModel.InvoiceModel>>(request.InvoiceList);

            foreach (var item in lstDataMoel)
            {
                Console.WriteLine(item.BalanceRechargeID);
            }
        }
    }
}
