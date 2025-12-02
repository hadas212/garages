namespace GarageApi.Data
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }  // כתובת השרת MongoDB
        public string DatabaseName { get; set; }      // שם מסד הנתונים
        public string CollectionName { get; set; }    // שם הקולקשן שבו נשמרים המוסכים
    }
}
