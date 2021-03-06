﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnityMVCDemo.Models
{
    public class ArticleRepository : IArticleRepository
    {
        private static List<Article> Articles = new List<Article>();

        public ArticleRepository()
        {
            if (Articles.Count == 0)
            {
                //添加演示数据
                Add(new Article { Id = 1, Title = "福利平台Demo1", Content = "UnityMVCDemo", Author = "福利平台1", CreateTime = DateTime.Now });
                Add(new Article { Id = 2, Title = "福利平台Demo2", Content = "UnityMVCDemo", Author = "福利平台2", CreateTime = DateTime.Now });
                Add(new Article { Id = 3, Title = "福利平台Demo3", Content = "UnityMVCDemo", Author = "福利平台3", CreateTime = DateTime.Now });
            }
        }
        /// <summary>
        /// 获取全部文章
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Article> GetAll()
        {
            return Articles.OrderBy(o=>o.Id);
        }
        /// <summary>
        /// 通过ID获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Article Get(int id)
        {
            return Articles.Find(p => p.Id == id);
        }
        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Article Add(Article item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Articles.Add(item);
            return item;
        }
        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(Article item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = Articles.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            Articles.RemoveAt(index);
            Articles.Add(item);
            return true;
        }
        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            Articles.RemoveAll(p => p.Id == id);
            return true;
        }
    }
}