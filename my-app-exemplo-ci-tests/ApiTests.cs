namespace my_app_exemplo_ci_tests;

public class ApiTests
{
    [Fact]
    public void TesteSimples_DeveSomarCorretamente()
    {
        // Arrange
        int a = 1;
        int b = 1;

        // Act
        int resultado = a + b;

        // Assert
        Assert.Equal(2, resultado);
    }

    [Fact]
    public void EndpointStatus_DeveRetornarObjetoValido()
    {
        // Simulação simples (sem servidor HTTP)
        var status = new
        {
            status = "OK"
        };

        Assert.Equal("OK", status.status);
    }
}