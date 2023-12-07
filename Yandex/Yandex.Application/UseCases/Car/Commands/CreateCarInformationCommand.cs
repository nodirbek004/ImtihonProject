using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Application.UseCases.Car.Commands
{
    public class CreateCarInformationCommand : IRequest<bool>
    {
        public string Color { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }

    }
}
