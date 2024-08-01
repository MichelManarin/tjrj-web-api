using CloudBooks.API.Presentation.ViewModel;

namespace CloudBooks.UnitTests.Helpers
{
    public static class TestDataGenerator
    {
        public static AutorViewModel CreateFakeAutorViewModel()
        {
            return new AutorViewModel(1, "Any Name");
        }
        public static Autor CreateFakeAutorModel()
        {
            return new Autor("Any Autor");
        }

        public static int CreateFakeAutorId()
        {
            return 99;
        }

        public static AssuntoViewModel CreateFakeAssuntoViewModel()
        {
            return new AssuntoViewModel(1, "Any Name");
        }
        public static Assunto CreateFakeAssuntoModel()
        {
            return new Assunto("Any Autor");
        }

        public static int CreateFakeAssuntoId()
        {
            return 99;
        }
        //public static AddressViewModel CreateFakeAddressViewModel()
        //{
        //    return new AddressViewModel
        //    {
        //        Street = "fake street",
        //        City = "fake city",
        //        State = "fake state",
        //        Country = "fake country",
        //        ZipCode = "89040-115"
        //    };
        //}

        //public static Address CreateFakeAddressModel()
        //{
        //    return new Address("fake street", "fake city", "fake state", "fake country", "89040-115");
        //}

        //public static Store CreateFakeStoreModel()
        //{
        //    return new Store(1, "Any name", CreateFakeAddressModel(), "Any phone number");
        //}
        //public static Company CreateFakeCompanyModel()
        //{
        //    return new Company("Any compant", CreateFakeAddressModel());
        //}

        //public static int GetFakeCompanyId()
        //{
        //    return 7;
        //}

        //public static StoreViewModel CreateFakeStoreViewModel()
        //{
        //    return new StoreViewModel
        //    {
        //        Id = 1,
        //        Name = "Fake Store",
        //        PhoneNumber = "Fake Number",
        //        Address = CreateFakeAddressViewModel(),
        //    };
        //}


    }
}
