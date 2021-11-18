using NerdStore.core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            
            AssertionConcern.ValidarSeMenorIgualQue(altura, 1, "A altura deve ser maior ou igual a 1");
            AssertionConcern.ValidarSeMenorIgualQue(largura, 1, "A largura deve ser maior ou igual a 1");
            AssertionConcern.ValidarSeMenorIgualQue(profundidade, 1, "A profundidade deve ser maior ou igual a 1");
            
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }
    }
}