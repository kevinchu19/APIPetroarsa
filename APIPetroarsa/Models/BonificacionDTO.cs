namespace ApiPetroarsa.Models
{
    public class BonificacionDTO
    {
        public string ExternalId__c { get; set; }
        public string Atributo_por_producto__c { get; set; }
        public decimal Bonificaci_n_1__c { get; set; }
        public decimal Bonificaci_n_2__c { get; set; }
        public decimal Cantidad_desde__c { get; set; }
        public decimal Cantidad_hasta__c { get; set; }
        public string Condici_n_de_pago__c { get; set; }
        public string Name { get; set; }
        public string Tipo_de_producto__c { get; set; }
        public decimal Tolerancia__c { get; set; }

    }
}
