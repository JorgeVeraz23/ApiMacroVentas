namespace MacroVentasEnterprise.DTO
{
    public class UtilitiesRequest
    {
    }

    public class  ValueLabelRequest
    {
        public string Value { get; set; }
        public string Label { get; set; }
    }

    public class SecondValueLabelRequest
    {
        public long Value { get; set; }
        public string Label { get; set; }
    }
}
