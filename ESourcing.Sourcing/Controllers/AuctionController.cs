using AutoMapper;
using ESourcing.Sourcing.Entities;
using ESourcing.Sourcing.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ESourcing.Sourcing.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuctionController : Controller
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IBidRepository _bidRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AuctionController> _logger;

        public AuctionController(
            IAuctionRepository auctionRepository,
            IBidRepository bidRepository,
            IMapper mapper,
            ILogger<AuctionController> logger
            )
        {
            _auctionRepository = auctionRepository;
            _bidRepository = bidRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Auction>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Auction>> GetAuctions()
        {
            var auctions = await _auctionRepository.GetAuctions();
            return Ok(auctions);
        }

        [HttpGet("{id:length(24)}", Name ="GetAuction")]
        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Auction>> GetAuction(string id)
        {
            var auction = await _auctionRepository.GetAuction(id);
            if(auction == null)
            {
                _logger.LogError($"Auction with id : {id} has not been found.");
                return NotFound();
            }

            return Ok(auction);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Auction>> CreateAuction(Auction auction)
        {
            await _auctionRepository.Create(auction);
            return CreatedAtRoute("GetAuction", new { id=auction.Id}, auction);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Auction>> UpdateAuction(Auction auction)
        {
            return Ok(await _auctionRepository.Update(auction));      
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Auction), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Auction>> DeleteAuctionById(string id)
        {
            return Ok(await _auctionRepository.Delete(id));
        }



    }
}
