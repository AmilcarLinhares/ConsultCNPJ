using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CNPJ.Domain.DTO
{
    public class ResponseApiWsDTO
    {
        public ResponseApiWsDTO(int empresaId)
        {
            EmpresaId = empresaId;
        }
        
        [Key]
        public int EmpresaId { get; set; }

        public List<ResponseQsaApiWsDTO> qsa { get; set; }

        public List<ResponseApApiWsDTO> atividade_principal { get; set; }

        public List<ResponseAsApiWsDTO> atividades_secundarias { get; set; }


        public string MsgErro { get; set; }

        [JsonPropertyName("situacao")]
        public string Situacao { get; set; } //":"ATIVA",
        
        [JsonPropertyName("bairro")]
        public string Bairro { get; set; } //":"JARDIM BOTANICO",

        [JsonPropertyName("logradouro")] 
        public string Logradouro { get; set; } //":"R LOPES QUINTAS",

        [JsonPropertyName("numero")] 
        public string Numero { get; set; } //":"303",

        [JsonPropertyName("cep")]
        public string Cep { get; set; } //":"22.460-901",

        [JsonPropertyName("municipio")]
        public string Municipio { get; set; } //":"RIO DE JANEIRO",

        [JsonPropertyName("porte")]
        public string Porte { get; set; } //":"DEMAIS",

        [JsonPropertyName("abertura")]
        public string Abertura { get; set; } //":"31/01/1986",

        [JsonPropertyName("natureza_juridica")]
        public string natureza_juridica { get; set; } //":"205-4 - Sociedade Anônima Fechada",

        [JsonPropertyName("fantasia")]
        public string Fantasia { get; set; } //":"TV/REDE/CANAIS/G2C+GLOBO SOMLIVRE GLOBO.COM GLOBOPLAY",

        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; } //":"27.865.757/0001-02",

        [JsonPropertyName("ultima_atualizacao")]
        public string ultima_atualizacao { get; set; } //":"2021-08-20T21:47:44.113Z",

        [JsonPropertyName("status")]
        public string Status { get; set; } //":"OK",

        [JsonPropertyName("complemento")]
        public string Complemento { get; set; } //":"",

        [JsonPropertyName("email")]
        public string Email { get; set; } //":"",

        [JsonPropertyName("efr")]
        public string Efr { get; set; } //":"",

        [JsonPropertyName("motivo_situacao")]
        public string MotivoSituacao { get; set; } //":"",

        [JsonPropertyName("situacao_especial")]
        public string SituacaoEspecial { get; set; } //":"",

        [JsonPropertyName("data_situacao_especial")]
        public string DataSituacaoEspecial { get; set; } //":"",

        [JsonPropertyName("capital_social")]
        public string capital_social { get; set; } //":"6983568523.86",

        [JsonPropertyName("data_situacao")]
        public string DataSituacao { get; set; } //":"03/11/2005",

        [JsonPropertyName("tipo")]
        public string Tipo { get; set; } //":"MATRIZ",

        [JsonPropertyName("nome")]
        public string Nome { get; set; } //":"GLOBO COMUNICACAO E PARTICIPACOES S/A",

        [JsonPropertyName("uf")]
        public string Uf { get; set; } //":"RJ",

        [JsonPropertyName("telefone")]
        public string Telefone { get; set; } //":"(21) 2155-4551/ (21) 2155-4552",
    }

    public class ResponseApApiWsDTO // Atividade Principal
    {
        [Key]
        public int ApId { get; set; }
        [ForeignKey("EmpresaId")]
        public int EmpresaId { get; set; }
        public string text { get; set; } //"text":"Atividades de televisão aberta"

        public string code { get; set; } //"code":"60.21-7-00"
    }

    public class ResponseAsApiWsDTO // Atividade Secundaria
    {
        [Key]
        public int AsId { get; set; }
        [ForeignKey("EmpresaId")]
        public int EmpresaId { get; set; }
        public string text { get; set; } //"text":"Atividades de televisão aberta"
        public string code { get; set; } //"code":"60.21-7-00"
    }

    public class ResponseQsaApiWsDTO
    {
        [Key]
        public int DiretorId { get; set; }
        [ForeignKey("EmpresaId")]
        public int EmpresaId { get; set; }
        public string qual { get; set; } //qual":"10-Diretor",

        [JsonPropertyName("nome")]
        public string Nome { get; set; } //"nome":"JORGE LUIZ DE BARROS NOBREGA"
    }
}