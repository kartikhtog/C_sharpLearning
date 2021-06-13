namespace skills.NullObjectPattern
{
    public interface IAbstraction
    {
        public int ReturnSomething(int SomeParameter);

        public static IAbstraction Null { get { return new Default(); } }
        private class Default : IAbstraction
        {
            public int ReturnSomething(int SomeParameter)
            {
                return 0;
            }
        }
    }
}
