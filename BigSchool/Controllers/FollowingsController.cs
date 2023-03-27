using BigSchool.DTOs;
using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            /*var userId = User.Identity.GetUserId();
            if(_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == ffol)) { }
            if (userId == null)
                return BadRequest("Please login first....");
            if (userId == follow.FolloweeId)
                return BadRequest("Can not follow myself....");

            Following find = _dbContext.Followings.FirstOrDefault(p => p.FollowerId == userId && p.FolloweeId == follow.FolloweeId);
            if (find == null)
            {
                return BadRequest("The already following exists!");
            }

            follow.FollowerId = userId;
            _dbContext.Followings.Add(follow);
            _dbContext.SaveChanges();

            return Ok();*/
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists!!!");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };

            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
