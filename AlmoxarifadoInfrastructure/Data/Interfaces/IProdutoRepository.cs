using AlmoxarifadoDomain.Models;
using AlmoxarifadoDomain.NomeDaPasta;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IProdutoRepository
    {
        Produto ObterProdutoPorId(int idProduto);
    }
}