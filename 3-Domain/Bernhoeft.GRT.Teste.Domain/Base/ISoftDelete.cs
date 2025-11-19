namespace Bernhoeft.GRT.Teste.Domain.Base
{
    public interface ISoftDelete
    {
        DateTime? DeletadoEm { get; set; }
        void UndoDelete();
    }
}