type StoryRowProps = {
    story: Story;
}

async function deleteStoryAsync(id: number): Promise<void> {

    const res = await fetch(`https://localhost:7177/story/${id}`,
    { method: 'DELETE' });

    if (!res.ok) {
        console.log(res);
        throw new Error('could not delete user from backend');
    }
}

export function StoryRow(props: StoryRowProps) {
    const story = props.story;

    const handleDelete = async () => {
        try {
            await deleteStoryAsync(props.story.id!);
        } catch (error) {
            console.log(error);
        }
    };

    return <>
        <div className="story-row">
            <span>{story.title}</span> <div><button onClick={handleDelete}>Delete</button> <button>Read</button></div>
        </div>
    </>
}