namespace Sistema_POS_NEW.ModeloVw
{
    public class ProductosVw
    {

        public string? status { get; set; }

        public int? id { get; set; }

        public string? Codigo { get; set; } = null!;

        public string? NombreProducto { get; set; } = null!;

        public string? Valor { get; set; } = null!;

       // public string ImgProducto { get; set; } = null!;

        public string? TipoProducto { get; set; } = null!;

        public string? FkFormulario { get; set; }


    }
}
