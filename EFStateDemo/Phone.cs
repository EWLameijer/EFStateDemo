namespace EFTest2
{
    class Phone
    {
        public long PhoneId { get; set; }

        public string Type { get; set; }

        public long BrandId { get; set; }

        public Brand Brand { get; set; }
    }
}
