type StoryRowProps = {
    story: Story;
}
export function StoryRow(props: StoryRowProps) {
    const story = props.story;
    return <>
        <div className="story-row">
            <span>{story.title}</span> <div><button>Edit</button> <button>Read</button></div>
        </div>
    </>
}