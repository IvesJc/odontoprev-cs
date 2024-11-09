# OdontoPrevApplication - Sorriso Ativo

<p>👥 Integrantes:  </p>
<p>Ellie de Oliveira  </p>
<p>RM: 552824  </p>
<p>🎯 Responsável pela integração dos serviços de backend com a API. </p> 

<p>Ives Jundi Chiba  </p>
<p>RM: 553243  </p>
<p>💻 Responsável pelo desenvolvimento das funcionalidades de comunicação com a API.  </p>

<p>Nathalia Comeron Freire  </p>
<p>RM: 553233  </p>
<p>💻 Responsável pelo desenvolvimento e consumo da API em Kotlin  </p>


## Definição do Projeto

### Objetivo do Projeto
O projeto Sorriso Ativo visa incentivar e recompensar os usuários pela manutenção de cuidados diários com a saúde bucal. A plataforma interativa permite que os beneficiários acumulem pontos ao realizar consultas, completar desafios e registrar hábitos de saúde bucal. Esses pontos podem ser trocados por prêmios e benefícios exclusivos, promovendo um estilo de vida mais saudável.

### Escopo
O escopo do projeto abrange o desenvolvimento de uma API que gerencia beneficiários, recompensas, missões e serviços relacionados à saúde bucal. As funcionalidades principais incluem:
- Registro e gerenciamento de beneficiários.
- Acompanhamento de missões e hábitos de saúde bucal.
- Sistema de recompensas por interações dos usuários.
- Integração com prestadores de serviços e empresas contratantes.
- Consulta e gerenciamento de endereços.

### Requisitos Funcionais e Não Funcionais

#### Requisitos Funcionais
- Cadastro e gerenciamento de beneficiários.
- Registro de missões e acompanhamento de progresso.
- Sistema de pontos e recompensas.
- Integração com prestadores de serviços e empresas contratantes.
- Consulta e gerenciamento de endereços.

#### Requisitos Não Funcionais
- A aplicação deve ser desenvolvida utilizando .NET Core.
- Implementação da arquitetura limpa (Clean Architecture) para garantir a separação de responsabilidades.
- Segurança nas operações de cadastro e acesso a dados.
- Escalabilidade para suportar um número crescente de usuários e dados.

## Desenho da Arquitetura

### Clean Architecture
O projeto utiliza a Clean Architecture para promover um código desacoplado, onde cada camada tem responsabilidades bem definidas. Essa abordagem facilita a manutenção e evolução da aplicação.

### Camadas da Aplicação

#### Apresentação
A camada de apresentação é responsável pela interface da API, onde os endpoints são expostos. Essa camada é responsável por receber as requisições e retornar as respostas apropriadas.

#### Aplicação
Nesta camada estão localizados os serviços e casos de uso da aplicação. Aqui, são implementadas as regras de negócios e a lógica que coordena as operações entre as camadas de domínio e apresentação.

#### Domínio
A camada de domínio contém os modelos e as regras de negócio. Aqui são definidos os objetos que representam os conceitos principais da aplicação, como `Beneficiario`, `Missao`, `Recompensa`, entre outros.

#### Infraestrutura
A camada de infraestrutura é responsável pelo acesso a dados, integração com APIs externas e outros serviços de backend. Essa camada implementa os repositórios que facilitam a comunicação com o banco de dados, utilizando Entity Framework Core.

## Estrutura do Projeto
A estrutura do projeto é organizada em pastas que correspondem às camadas da arquitetura. A seguir, apresentamos uma visão geral das principais pastas:

/SorrisoAtivo.Presentation # Camada de apresentação

/SorrisoAtivo.Application # Camada de aplicação

/SorrisoAtivo.Domain # Camada de domínio

/SorrisoAtivo.Infrastructure # Camada de infraestrutura

## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença
Este projeto está licenciado sob a MIT License. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## Contato
Para mais informações, entre em contato com a equipe de desenvolvimento da Adaptive Dialogs.
