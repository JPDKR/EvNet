namespace EvNet.Domain.Entities
{
    public class Facturas
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; } = string.Empty;
        public decimal Importe { get; set; }

        public virtual Clientes? Clientes { get; set; }
    }
}
