using System.Runtime.Serialization;

[DataContract]
public class FinancialMovement
{
    [DataMember]
    public int Index { get; set; }

    [DataMember]
    public float Monto { get; set; }

    [DataMember]
    public string Fecha { get; set; }

    [DataMember]
    public string Movimiento { get; set; } // "Ingreso", "Gasto" o "Venta"
}
