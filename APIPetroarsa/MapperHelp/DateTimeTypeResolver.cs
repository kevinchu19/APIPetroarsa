using ApiPetroarsa.Models;
using ApiPetroarsa.Entities;
using AutoMapper;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ApiPetroarsa.MapperHelp
{
    public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            return source==null ? DateTime.Now : System.Convert.ToDateTime(DateTime.ParseExact(source, "yyyyMMdd",
                CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
        }
    }
}