Feature: Consultas no site dos Correios
  Validar CEPs e códigos de rastreamento

  Scenario: Validar consultas
    Given que abro o site dos correios
    When busco pelo CEP "80700000"
    Then devo ver a mensagem "Não há dados a serem exibidos"
    When busco pelo CEP "01013-001"
    Then o resultado deve conter "Rua Quinze de Novembro - Sé, São Paulo/SP"
    When busco pelo código de rastreamento "SS987654321BR"
    Then devo ver a mensagem "Objeto não encontrado na base de dados dos Correios"
    And fecho o navegador
