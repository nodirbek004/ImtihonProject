using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandex.Application.Abcreactions;
using Yandex.Application.UseCases.Order.Commands;

namespace Yandex.Application.UseCases.Order.Handlers
{
    public class UpdateOrderCommandHendler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IAppDbContext appDbContext;

        public UpdateOrderCommandHendler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var existCar = await appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (existCar is null)
            {
                throw new Exception("Order not found");
            }
            appDbContext.Orders.Update(existCar);
            var res = await appDbContext.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}
