namespace GarageApi.Models
{
    public class Garage
    {
        public int Id { get; set; }                 // _id מה-JSON
        public int MisparMosah { get; set; }        // mispar_mosah
        public string Name { get; set; }            // shem_mosah
        public int CodSugMosah { get; set; }        // cod_sug_mosah
        public string SugMosah { get; set; }        // sug_mosah
        public string Address { get; set; }         // ktovet
        public string City { get; set; }            // yishuv
        public string Telephone { get; set; }       // telephone
        public int Mikud { get; set; }              // mikud
        public int CodMiktzoa { get; set; }         // cod_miktzoa
        public string Miktzoa { get; set; }         // miktzoa
        public string MenahelMiktzoa { get; set; }  // menahel_miktzoa
        public long LicenseNumber { get; set; }     // rasham_havarot
        public string Testime { get; set; }         // TESTIME
    }
}
