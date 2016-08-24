namespace DynamicIsNotMagic
{
    public class BasicExamplesWhereCanUse
    {
        public dynamic DynamicProperty { get; set; }
        dynamic _dynamicProperty;

        public void DynamicArgs(dynamic dynamicParam)
        {
        }

        public dynamic ReturnType()
        {
            return "I'll be casted";
        }
    }
}
