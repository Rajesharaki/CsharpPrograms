using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationBusiness.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundooAPI.Controllers
{
    /// <summary>
    /// this is the Labels Controller class
    /// </summary>
    ////[Authorize]
    [Route("api/[controller]")]
    public class LabelsController : Controller
    {
        /// <summary>
        /// LabelManager to manager the labels
        /// </summary>
        private readonly ILabelManager labelManager;

        /// <summary>
        /// Constructor injection of LabelsManager
        /// </summary>
        /// <param name="labelManager">DE of LabelsManager</param>
        public LabelsController(ILabelManager labelManager)
        {
            this.labelManager = labelManager;
        }

        /// <summary>
        /// Adds the new Label
        /// </summary>
        /// <param name="model">from body</param>
        /// <returns>Result</returns>
        [HttpPost, Route("add")]
        public async Task<IActionResult> Add([FromBody]LabelsModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.labelManager.AddLabel(model);
                if (result==1)
                {
                    return Ok(result);
                }
                return this.NotFound(result);
             }
            return this.BadRequest();
        }

        /// <summary>
        /// updates the label
        /// </summary>
        /// <param name="model">from body</param>
        /// <returns>Result</returns>
        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody]LabelsModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.labelManager.UpdateLabel(model);
                return Ok(result);
            }
            return this.NotFound();
        }

        /// <summary>
        /// Gets the Label based on the id
        /// </summary>
        /// <param name="id">from body</param>
        /// <returns>Result</returns>
        [HttpGet, Route("get")]
        public IActionResult Get([FromBody]int id)
        {
            var model = this.labelManager.GetLabel(id);
            if (model != null)
            {
                return this.NotFound();
            }
            return this.Ok(model);
        }

        /// <summary>
        /// Deletes the Label
        /// </summary>
        /// <param name="id">from body</param>
        /// <returns>Result</returns>
        [HttpDelete, Route("delete")]
        public async Task<IActionResult> Delete([FromBody]int id)
        {
            var result = await this.labelManager.DeleteLabel(id);
            if (result == 1)
            {
                return this.Ok(result);
            }
            return this.NotFound();
        }

        /// <summary>
        /// gets all the labels
        /// </summary>
        /// <returns>Result</returns>
        [HttpGet, Route("getall")]
        public IActionResult GetAll()
        {
            var result = this.labelManager.GetAllLabels();
            if (result != null)
            {
                return Ok(result);
            }
            return this.NotFound();
        }
    }
}
