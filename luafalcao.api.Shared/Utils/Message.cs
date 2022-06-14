using luafalcao.api.Shared.Enums;
using System;
using System.Collections.Generic;

namespace luafalcao.api.Shared.Utils
{
    public class Message<T>
    {
        public T Data { get; set; }
        public bool Success { get ; set; }
        public int StatusCode { get; set; }
        public string Description { get; set; }
        public IList<string> Validations = new List<string>();
        public Exception Exception { get; set; }

        public Message()
        {
            StatusCode = (int) StatusCodeEnum.Ok;
        }

        public void Ok(T data)
        {
            Data = data;
            Success = true;
            StatusCode = (int) StatusCodeEnum.Ok;
        }

        public void Ok()
        {
            Success = true;
            StatusCode = (int)StatusCodeEnum.Ok;
            Description = "Operação realizada com sucesso.";
        }

        public void Created(T data)
        {
            Data = data;
            Success = true;
            StatusCode = (int)StatusCodeEnum.Created;
            Description = "Recurso cadastrado com sucesso";
        }

        public void Error(Exception error)
        {
            Success = false;
            Exception = error;
            StatusCode = (int)StatusCodeEnum.InternalServerError;
            Description = "Ops! Ocorreu um erro.";
        }

        public void BadRequest(IList<string> validations = null)
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.BadRequest;
            Validations = validations != null ? validations : Validations;
            Description = "Ops! Verifique os dados informados.";
        }

        public void NotFound()
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.NotFound;
            Description = "O conteúdo solicitado não está cadastrado no banco de dados.";
        }

        public void NoContent()
        {
            Success = true;
            StatusCode = (int)StatusCodeEnum.NoContent;
            Description = "Operação realizada com sucesso.";
        }

        public void Unauthorized()
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.Unauthorized;
        }
    }

    public class Message 
    {
        public bool Success { get; set; }
        public IList<string> Validations = new List<string>();
        public string Description { get; set; }
        public int StatusCode { get; set; }
        public Exception Exception { get; set; }

        public void Created()
        {
            Success = true;
            StatusCode = (int)StatusCodeEnum.Created;
            Description = "Recurso cadastrado com sucesso.";
        }

        public void Ok()
        {
            Success = true;
            StatusCode = (int)StatusCodeEnum.Ok;
            Description = "Operação realizada com sucesso.";
        }

        public void Error(Exception error)
        {
            Success = false;
            Exception = error;
            StatusCode = (int)StatusCodeEnum.InternalServerError;
            Description = "Ops! Ocorreu um erro.";
        }

        public void Error()
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.InternalServerError;
            Description = "Ops! Ocorreu um erro.";
        }

        public void NotFound()
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.NotFound;
            Description = "O conteúdo solicitado não está cadastrado no banco de dados.";
        }

        public void NoContent()
        {
            Success = true;
            StatusCode = (int)StatusCodeEnum.NoContent;
            Description = "Operação realizada com sucesso.";
        }

        public void BadRequest(IList<string> validations = null)
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.BadRequest;
            Validations = validations != null ? validations : Validations;
            Description = "Ops! Verifique os dados informados.";
        }
    }
}