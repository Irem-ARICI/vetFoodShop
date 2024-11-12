namespace vetFoodShop.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings   // implament ettik de alttaki gibi yzmadı {set, get} şeklinde yazdıı :)
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImageCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        //public string CategoryCollectionName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string ProductCollectionName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string ProductDetailCollectionName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string ProductImageCollectionName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string DatabaseName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
