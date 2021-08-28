using GestionStock.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeStock.API.Middelwares
{
    public class RedirectionMidelware
    {
        RequestDelegate _next;
        public RedirectionMidelware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context,GestionStockContext _context)
        {
            var path = context.Request.Path.ToUriComponent();
            var entity = _context.Reroutings.FirstOrDefault(f => f.OldUrl == path);
            if (entity != null)
            {
                context.Response.Redirect(entity.NewUrl, permanent: true);
                return;
            }
            await _next.Invoke(context);
        }


    }
}

