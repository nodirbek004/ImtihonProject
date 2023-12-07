using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandex.Domain.Commons;

namespace Yandex.Application.UseCases.Car.Commands
{
    public class DeleteCarInformationCommand:AudiTable,IRequest<bool>
    {

    }
}
