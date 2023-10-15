using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        //protected IUnitOfWork _unitOfWork;
        public string currentUserName ;
        public string UserIP ;
        public BaseController()
        {
            //_unitOfWork = unitOfWork;
            currentUserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
            UserIP="";
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    UserIP = ip.ToString();
                }
            }
            //_unitOfWork.setUserInfo(current, UserIP);
        }
    }
}
