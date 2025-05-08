using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Raja_File_API.Models;

namespace Raja_File_API.Controllers
{
    [RoutePrefix("api/file")] // <-- Required to build full route
    public class FileController : ApiController
    {
        [HttpPost]
        [Route("upload")]
        public IHttpActionResult Upload()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var file = httpRequest.Files["file"];
                List<DataRecord> records = new List<DataRecord>();
                List<string> columnHeader = new List<string>();

                if (file != null && file.ContentLength > 0)
                {
                    using (var reader = new StreamReader(file.InputStream))
                    {
                        var rawLines = new List<string[]>();
                        int maxCols = 0;

                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine()?.Trim();
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                var parts = line
                                    .Split(',')
                                    .Select(p => p.Trim())
                                    .Where(p => !string.IsNullOrEmpty(p)) // Exclude empty values
                                    .ToArray();

                                if (parts.Length > 0)
                                {
                                    rawLines.Add(parts);
                                    maxCols = Math.Max(maxCols, parts.Length);
                                }
                            }

                        }

                        // Determine header as the row with max columns
                        var headerRow = rawLines.FirstOrDefault(r => r.Length == maxCols);
                        columnHeader = headerRow != null
                            ? headerRow.Select(h => string.IsNullOrWhiteSpace(h) ? "Column" : h).ToList()
                            : Enumerable.Range(1, maxCols).Select(i => $"Column{i}").ToList();

                        foreach (var lineParts in rawLines)
                        {
                            // Skip the header row
                            if (lineParts.SequenceEqual(headerRow))
                                continue;

                            var paddedParts = lineParts.Concat(
                                Enumerable.Repeat(string.Empty, maxCols - lineParts.Length)
                            ).ToList();

                            records.Add(new DataRecord
                            {
                                Columns = paddedParts
                            });
                        }
                    }
                }

                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest($"Upload Error Is: {ex.Message}");
            }
        }
    }
}
