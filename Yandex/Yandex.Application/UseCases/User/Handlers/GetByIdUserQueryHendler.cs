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
    public class GetByIdUserQueryHendler : IRequestHandler<GetByIdUserQuery, Domain.Entities.User>
    {
        private readonly IAppDbContext appDbContext;

        public GetByIdUserQueryHendler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Domain.Entities.User> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var res = await appDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                throw new Exception("yoq bunday orin");
            }
            return res;
        }
    }
}
