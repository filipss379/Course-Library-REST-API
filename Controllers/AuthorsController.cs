﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTful_API.API.Services;
using Microsoft.AspNetCore.Cors;
using RESTful_API.Models;
using RESTful_API.Helper;
using AutoMapper;

namespace RESTful_API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;
        public AuthorsController(ICourseLibraryRepository courseLibraryRepository,
            IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors();            
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo)); 
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthors(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

            if(authorFromRepo == null) 
            {
                return NotFound(); 
            }

            return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
        }
    }
}
