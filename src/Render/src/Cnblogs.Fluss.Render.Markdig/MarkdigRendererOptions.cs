using Markdig;

namespace Cnblogs.Fluss.Render.Markdig
{
    /// <summary>
    /// Configure Markdig's <see cref="MarkdownPipeline"/>.
    /// </summary>
    public class MarkdigRendererOptions
    {
        /// <summary>
        /// The <see cref="MarkdownPipeline"/> that renderer used by default. It may be override by the config that content block uses.
        /// </summary>
        public MarkdownPipeline Pipeline { get; internal set; } =
            new MarkdownPipelineBuilder().UseEmojiAndSmiley().UseAdvancedExtensions().Build();
    }
}