using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts.Exceptions.Trainers;
public class TrainerNotFoundException : Exception
{
    public override string Message => "Le dresseur n'existe pas";
}
