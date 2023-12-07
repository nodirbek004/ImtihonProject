using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.User.Queries;

namespace Yandex.Application.UseCases.User.Handlers
{
    public class GetAllUserQueryHendler : IRequestHandler<GetAllUserQuery, List<Domain.Entities.User>>
    {
        private readonly IAppDbContext appDbContext;

        public GetAllUserQueryHendler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Domain.Entities.User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var res = await appDbContext.Users.ToListAsync(cancellationToken);
            return res;
        }
    }
}
