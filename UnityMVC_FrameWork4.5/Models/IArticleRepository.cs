﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnityMVCDemo.Models
{
    /// <summary>
    /// IArticleRepository接口
    /// </summary>
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();
        Article Get(int id);
        Article Add(Article item);
        bool Update(Article item);
        bool Delete(int id);
    }
}