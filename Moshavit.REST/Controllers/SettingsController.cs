using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moshavit.Entity;
using Moshavit.Entity.Dto;
using Moshavit.Entity.Dto.messages;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.Interfaces;
using Moshavit.Service;

namespace Moshavit.REST.Controllers
{
    public class SettingsController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IMessageService<BabySitterTable, BabySitterMessageDto> _babyService;
        private readonly IMessageService<CarPullTable, CarpullMessageDto> _carpullService;
        private readonly IMessageService<BulletinBoardTable, BulletinBoardDto> _bulltinboardService;
        public SettingsController(IUserService userService, 
            IMessageService<BabySitterTable, BabySitterMessageDto> babyService, 
            IMessageService<CarPullTable, CarpullMessageDto> carpullService,
            IMessageService<BulletinBoardTable, BulletinBoardDto> bulltinboardService)
        {
            _userService = userService;
            _babyService = babyService;
            _carpullService = carpullService;
        }
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var num = 0;

            #region Users
            var user = new List<UserRegistertionData>
            {
                new UserRegistertionData
                {
                    FirstName = "Joe", LastName = "Bob", Email = "name@domain.com", Password = "1234", Phone = "05222222", Address = "street"
                },
                new UserRegistertionData
                {
                    FirstName = "Dany", LastName = "Shimon", Email = "name1@domain.com", Password = "1234", Phone = "05222222", Address = "street"
                },
                new UserRegistertionData
                {
                    FirstName = "Rotem", LastName = "Levi", Email = "name2@domain.com", Password = "1234", Phone = "05222222", Address = "street"
                },
                new UserRegistertionData
                {
                    FirstName = "Azriel", LastName = "Kobi", Email = "name3@domain.com", Password = "1234", Phone = "05222222", Address = "street"
                },
                new UserRegistertionData
                {
                    FirstName = "Sara", LastName = "Choen", Email = "name4@domain.com", Password = "1234", Phone = "05222222", Address = "street"
                },
                new UserRegistertionData
                {
                    FirstName = "Jimme", LastName = "Mike", Email = "name5@domain.com", Password = "1234", Phone = "05222222", Address = "street"
                }
            };

            foreach (var data in user)
            {
                try
                {
                    _userService.Register(data);
                }
                catch (Exception)
                {
                    num++;
                }
                
            }

            #endregion

            #region BabySiter

            var babysitter = new List<BabySitterMessageDto>
            {
                new BabySitterMessageDto
                {
                    IdUser = 1,
                    Title = "Baby Siter 1",
                    Content = "Content Type",
                    StartTime = new DateTime(2014, 9, 25, 18, 0, 0),
                    EndTime = new DateTime(2014, 9, 25, 18, 0, 0),
                    Rate = 30.0
                },
                new BabySitterMessageDto
                {
                    IdUser = 2,
                    Title = "Baby Siter 1",
                    Content = "Content Type",
                    StartTime = new DateTime(2014, 9, 25, 18, 0, 0),
                    EndTime = new DateTime(2014, 9, 25, 18, 0, 0),
                    Rate = 30.0
                },
                new BabySitterMessageDto
                {
                    IdUser = 2,
                    Title = "Baby Siter 1",
                    Content = "Content Type",
                    StartTime = new DateTime(2014, 9, 25, 18, 0, 0),
                    EndTime = new DateTime(2014, 9, 25, 18, 0, 0),
                    Rate = 30.0
                },
                new BabySitterMessageDto
                {
                    IdUser = 3,
                    Title = "Baby Siter 1",
                    Content = "Content Type",
                    StartTime = new DateTime(2014, 9, 25, 18, 0, 0),
                    EndTime = new DateTime(2014, 9, 25, 18, 0, 0),
                    Rate = 30.0
                },
            };

            foreach (var babySitterMessageDto in babysitter)
            {
                try
                {
                    _babyService.AddNewMessage(babySitterMessageDto);
                }
                catch (Exception)
                {
                    num++;
                }
                
            }
            #endregion

            #region Carpull

            var carpull = new List<CarpullMessageDto>
            {
                new CarpullMessageDto
                {
                    IdUser = 6,
                    Title = "carpull",
                    Content = "going to tel-aviv",
                    From = "home",
                    To = "work",
                    PickUp = new DateTime(2014, 9, 1, 8, 0, 0),
                    ReturnTime = new DateTime(2014, 9, 1, 18, 0, 0)
                },
                new CarpullMessageDto
                {
                    IdUser = 3,
                    Title = "carpull",
                    Content = "going to Ber sheva",
                    From = "home",
                    To = "work",
                    PickUp = new DateTime(2014, 9, 1, 8, 0, 0),
                    ReturnTime = new DateTime(2014, 9, 1, 18, 0, 0)
                },
                new CarpullMessageDto
                {
                    IdUser = 2,
                    Title = "carpull",
                    Content = "going to Lod",
                    From = "home",
                    To = "work",
                    PickUp = new DateTime(2014, 9, 1, 8, 0, 0),
                    ReturnTime = new DateTime(2014, 9, 1, 18, 0, 0)
                },
                new CarpullMessageDto
                {
                    IdUser = 4,
                    Title = "carpull",
                    Content = "going to Kfar saba",
                    From = "home",
                    To = "work",
                    PickUp = new DateTime(2014, 9, 1, 8, 0, 0),
                    ReturnTime = new DateTime(2014, 9, 1, 18, 0, 0)
                }
            };

            foreach (var carpullMessageDto in carpull)
            {
                try
                {
                    _carpullService.AddNewMessage(carpullMessageDto);
                }
                catch (Exception)
                {
                    num++;
                }
                
            }

            #endregion

            #region Bulletin Board

            var bulletin = new List<BulletinBoardDto>
            {
                new BulletinBoardDto{ IdUser = 4, Title = "Hello all", Content = "let meet", Description = "only for members", Details = "bring food"},
                new BulletinBoardDto{ IdUser = 2, Title = "Mazal TOV", Content = "let meet", Description = "only for members", Details = "bring food"},
                new BulletinBoardDto{ IdUser = 6, Title = "Title", Content = "let meet", Description = "only for members", Details = "bring food"},
                new BulletinBoardDto{ IdUser = 4, Title = "Movie", Content = "let meet", Description = "only for members", Details = "bring food"},
                new BulletinBoardDto{ IdUser = 1, Title = "Hello all", Content = "let meet", Description = "only for members", Details = "bring food"},
            };

            foreach (var bulletinBoardDto in bulletin)
            {
                try
                {
                    _bulltinboardService.AddNewMessage(bulletinBoardDto);
                }
                catch (Exception)
                {
                    num++;

                }
                
            }

            #endregion

            return Request.CreateResponse(HttpStatusCode.OK, num);
        }
    }
}