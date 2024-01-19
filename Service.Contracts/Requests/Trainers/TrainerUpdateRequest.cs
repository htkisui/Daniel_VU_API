using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Requests.Trainers;
public class TrainerUpdateRequest
{
    public int Id { get; set; }
    public string Name {  get; set; }
}
