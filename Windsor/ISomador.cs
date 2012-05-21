namespace Windsor
{
    public interface ISomador
    {
        int UmMaisUm();
    }

    public class SomadorDecimal : ISomador
    {
        #region ISomador Members

        public int UmMaisUm()
        {
            return 2;
        }

        #endregion
    }

    public class SomadorBinario : ISomador
    {
        #region ISomador Members

        public int UmMaisUm()
        {
            return 10;
        }

        #endregion
    }

    public interface IGenerico<out T>
    {
        string DeQuemEuSou();
    }

    public class SouDeString<T> : IGenerico<T>
    {
        public string DeQuemEuSou()
        {
            return typeof(T).Name;
        }
    }

    public class ClasseDependenteDeISomador
    {
        private readonly ISomador somadorBinario;
        
        public ClasseDependenteDeISomador(ISomador somadorBinario)
        {
            this.somadorBinario = somadorBinario;
        }

        public string ExecutaUmMaisUm()
        {
            return somadorBinario.UmMaisUm().ToString();
        }
    }
}