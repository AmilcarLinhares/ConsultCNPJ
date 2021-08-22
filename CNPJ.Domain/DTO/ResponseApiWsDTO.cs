using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CNPJ.Domain.DTO
{
    public class ResponseApiWsDTO
    {
        public ResponseApiWsDTO(int id)
        {
            Id = id;
        }
        
        public int Id { get; set; }

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
        public string NaturezaJuridica { get; set; } //":"205-4 - Sociedade Anônima Fechada",

        [JsonPropertyName("fantasia")]
        public string Fantasia { get; set; } //":"TV/REDE/CANAIS/G2C+GLOBO SOMLIVRE GLOBO.COM GLOBOPLAY",

        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; } //":"27.865.757/0001-02",

        [JsonPropertyName("ultima_atualizacao")]
        public DateTime UltimaAtualizacao { get; set; } //":"2021-08-20T21:47:44.113Z",

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
        public DateTime DataSituacaoEspecial { get; set; } //":"",

        [JsonPropertyName("capital_social")]
        public decimal CapitalSocial { get; set; } //":"6983568523.86",

        [JsonPropertyName("data_situacao")]
        public DateTime DataSituacao { get; set; } //":"03/11/2005",

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
        public string text { get; set; } //"text":"Atividades de televisão aberta"

        public string code { get; set; } //"code":"60.21-7-00"
    }

    public class ResponseAsApiWsDTO // Atividade Secundaria
    {
        public string text { get; set; } //"text":"Atividades de televisão aberta"

        public string code { get; set; } //"code":"60.21-7-00"
    }

    public class ResponseQsaApiWsDTO
    {
        public string qual { get; set; } //qual":"10-Diretor",

        [JsonPropertyName("nome")]
        public string Nome { get; set; } //"nome":"JORGE LUIZ DE BARROS NOBREGA"
    }
}
//27865757000102