using InlamningNet.Data;
using InlamningNet.DTO;
using InlamningNet.Entity;
using InlamningNet.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InlamningNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly NetDbcontext netDbcontext;
        private readonly ISubscriptionRepository subscriptionRepository;

        public SubscriptionController(NetDbcontext netDbcontext, ISubscriptionRepository subscriptionRepository)
        {
            this.netDbcontext = netDbcontext;
            this.subscriptionRepository = subscriptionRepository;
        }





        [HttpGet]
        public async Task<IActionResult> GetAll()
        {



            var subscriptionsDomain = await subscriptionRepository.GetAllAsync();

            var subscriptionsDto = new List<SubscriptionDto>();
            foreach (var subscriptionDomain in subscriptionsDomain)
            {

                subscriptionsDto.Add(new SubscriptionDto()
                {
                    SubscriptionId = subscriptionDomain.SubscriptionId,
                    Email = subscriptionDomain.Email,
                    SubscriptionDate = subscriptionDomain.SubscriptionDate,
                    ActiveStatus = subscriptionDomain.ActiveStatus,

                });

            }


            return Ok(subscriptionsDto);


        }


        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var subscriptionDomain = await subscriptionRepository.GetByIdAsync(id);

            if (subscriptionDomain == null)
            {
                return NotFound();
            }
            var subscriptionDto = new SubscriptionDto
            {
                SubscriptionId = subscriptionDomain.SubscriptionId,
                Email = subscriptionDomain.Email,
                SubscriptionDate = subscriptionDomain.SubscriptionDate,
                ActiveStatus = subscriptionDomain.ActiveStatus,
                
            };
            return Ok(subscriptionDto);

        }







        [HttpPost]

        public async Task<IActionResult> Create([FromBody] SubscriptionPostDto subscriptionPost)
        {
            var subscriptionDomainModel = new Subscription
            {
                Email = subscriptionPost.Email,
            };




            subscriptionDomainModel = await subscriptionRepository.CreateAsync(subscriptionDomainModel);


            var subscriptionDto = new SubscriptionDto
            {
                SubscriptionId = subscriptionDomainModel.SubscriptionId,
                Email = subscriptionDomainModel.Email,
                SubscriptionDate = subscriptionDomainModel.SubscriptionDate,
                ActiveStatus = subscriptionDomainModel.ActiveStatus,

            };
            return CreatedAtAction(nameof(GetById), new { id = subscriptionDto.SubscriptionId }, subscriptionDto);
        }




        [HttpDelete]
        [Route("{id:Guid}")]
        
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {

            var subscriptionDomainModel = await subscriptionRepository.DeleteAsync(id);


            if (subscriptionDomainModel == null)
            {


                return NotFound();
            }


            var subscriptionDto = new SubscriptionDto
            {
                SubscriptionId = subscriptionDomainModel.SubscriptionId,
                Email = subscriptionDomainModel.Email,
                SubscriptionDate = subscriptionDomainModel.SubscriptionDate,
                ActiveStatus = subscriptionDomainModel.ActiveStatus,

            };
            return CreatedAtAction(nameof(GetById), new { id = subscriptionDto.SubscriptionId }, subscriptionDto);





        }


        }
    }
