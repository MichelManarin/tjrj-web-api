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

        public static LivroViewModel CreateFakeLivroViewModel()
        {
            return new LivroViewModel(99, "Diario de Anne Frank", "Abril", 1, "1967", null, null);
        }
        public static Livro CreateFakeLivroModel()
        {
            return new Livro(99, "Diario de Anne Frank", "Abril", 1, "1967");  
        }

        public static int CreateFakeLivroId()
        {
            return 99;
        }
    }
}
