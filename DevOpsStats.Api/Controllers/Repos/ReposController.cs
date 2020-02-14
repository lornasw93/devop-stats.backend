﻿using System;
using System.Net;
using System.Web.Http;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Git.Repo;
using DevOpsStats.Api.Models.Project;
using DevOpsStats.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Repos
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/repos[controller]")]
    [ApiController]
    [Authorize]
    public class ReposController : ControllerBase
    {
        private readonly IDevOpsService _devOpsService;

        public ReposController(IDevOpsService devOpsService)
        {
            _devOpsService = devOpsService;
        }
         
        /// <summary>
        /// Get repo by project and repo Id
        /// </summary>
        /// <param name="project"></param>
        /// <param name="repoId"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Repo> Get(string project, Guid repoId)
        {
            return Ok(_devOpsService.GetGitRepo(project, repoId));
        }
         
        /// <summary>
        /// Get list of repos by project
        /// </summary>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Repo>> Get(string project)
        {
            return Ok(_devOpsService.GetGitRepos(project));
        }
    }
}