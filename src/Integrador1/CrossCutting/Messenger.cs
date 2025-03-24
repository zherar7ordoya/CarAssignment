namespace Integrador.CrossCutting;

public static class Messenger
{
    public static void MostrarMensaje(string mensaje, string titulo) => MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
    public static void MostrarError(string mensaje, Exception ex) => MessageBox.Show(ex.Message, mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
    public static bool MostrarConfirmacion(string mensaje, string titulo) => MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
}
