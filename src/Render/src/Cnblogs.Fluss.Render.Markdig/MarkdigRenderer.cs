using System;
using System.Threading.Tasks;
using Markdig;
using Microsoft.Extensions.Options;

namespace Cnblogs.Fluss.Render.Markdig
{
    /// <summary>
    /// Markdown renderer that uses <see cref="Markdig"/> as internal renderer.
    /// </summary>
    [RendererId("3D45AB46-30A8-4C0B-A6BD-9C0E79019B21")]
    public class MarkdigRenderer : IRenderer
    {
        private readonly MarkdigRendererOptions _options;

        public MarkdigRenderer(IOptions<MarkdigRendererOptions> options)
        {
            _options = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        /// <inheritdoc />
        public async Task<string> RenderAsync(string input, string config)
        {
            var pipeline = string.IsNullOrEmpty(config)
                ? _options.Pipeline
                : new MarkdownPipelineBuilder().Configure(config).Build();
            return await Task.FromResult(Markdown.ToHtml(input, pipeline));
        }
    }
}