using LiteDB;
using System.Reflection;

namespace MangoRPG_APP.Utils
{
    public class LiteDBHelper
    {

        //保存数据到Lite DB
        public string Save<T>(T obj, string collectionName) where T : new()
        {
            string path = DB.Path();
            using (var db = new LiteDatabase(path))
            {
                var col = db.GetCollection<T>(collectionName);
                var value = col.Insert(obj);
                return value.ToString();
            }
        }

        //更新Lite DB中的数据
        public bool Update<T>(T obj, string collectionName) where T : new()
        {
            using (var db = new LiteDatabase(DB.Path()))
            {
                var col = db.GetCollection<T>(collectionName);
                var success = col.Update(obj);
                return success;
            }
        }

        //删除Lite DB中的数据
        public bool Delete(int docId, string collectionName)
        {
            using (var db = new LiteDatabase(DB.Path()))
            {
                var col = db.GetCollection(collectionName);
                var success = col.Delete(docId);
                return success;
            }
        }

        //根据ID来查询Lite DB中的文档数据
        public BsonDocument FindById(int docId, string collectionName)
        {
            using (var db = new LiteDatabase(DB.Path()))
            {
                var col = db.GetCollection(collectionName);
                var doc = col.FindById(docId);
                return doc;
            }
        }


        //根据ID来查询Lite DB中的文档数据，并转换成对象
        public T FindById<T>(int docId, string collectionName) where T : new()
        {
            using (var db = new LiteDatabase(DB.Path()))
            {
                var col = db.GetCollection(collectionName);
                var doc = col.FindById(docId);
                return BsonToObject.ConvertTo<T>(doc);
            }
        }

        //查询Lite DB中的全部文档数据
        public IList<BsonDocument> FindAll(string collectionName)
        {
            using (var db = new LiteDatabase(DB.Path()))
            {
                var col = db.GetCollection(collectionName);
                var doc = col.FindAll().ToList();
                return doc;
            }
        }

        //查询Lite DB中的全部文档数据，并转换成对象集合
        public IList<T> FindAll<T>(string collectionName) where T : new()
        {
            using (var db = new LiteDatabase(DB.Path()))
            {
                var col = db.GetCollection<T>(collectionName);
                var doc = col.FindAll().ToList();
                return doc;
            }
        }
    }
    public class DB
    {
        //数据库文件路径
        //这个我不知道怎么去改路径到%appdata%中
        //如果有会的人来研究一下。
        public static string Path() => System.IO.Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory + string.Format("mangorpg.db"));
    }

    // BsonDocument转换成C#对象
    public class BsonToObject
    {
        public static T ConvertTo<T>(BsonDocument bd) where T : new()
        {
            T model = new T();
            PropertyInfo[] propertyInfos = model.GetType().GetProperties();
            foreach (var property in propertyInfos)
            {
                if (property != null && bd.ContainsKey(property.Name))
                {
                    property.SetValue(model, bd[property.Name], null);
                }
            }
            return model;
        }

        public static IList<T> ConvertToList<T>(List<BsonDocument> dbList) where T : new()
        {
            IList<T> list = new List<T>();
            foreach (var bd in dbList)
            {
                T _t = ConvertTo<T>(bd);
                if (_t != null)
                {
                    list.Add(_t);
                }
            }
            return list;
        }
    }
}
