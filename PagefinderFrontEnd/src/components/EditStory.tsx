import { ChangeEvent, FormEvent, useEffect, useState } from "react";

type EditStoryProps = {
    user: User;
    storyId: number | null;
    closeComponent: () => void;
}

async function fetchUserLibrary(id: number | undefined): Promise<User> {
    const response = await fetch(`https://localhost:7177/User/${id}/library/`);

    try {
        const resObject = await response.json();

        console.log(resObject);

        return resObject;
    }
    catch (error) {
        console.log(error);
        return { id: -1, username: 'bad request', email: '', password: '' };
    }
}

async function fetchStoryAsync(id: number | null): Promise<Story> {

    if (id !== null && id !== -1) {
        const response = await fetch(`https://localhost:7177/story/${id}`);
        try {
            const resObject = await response.json();

            console.log(resObject);

            console.log(resObject);
            return resObject;
        }
        catch (error) {
            console.log(error);
            return { id: -1, title: 'BadResponse', collectionId: -1 };
        }
    }
    else {
        console.log(`ID was ${id}`);
        return { id: -1, title: 'BadResponse', collectionId: -1 };
    }

}

async function updateStoryAsync(
    story: Story
): Promise<Story> {
    const res = await fetch(`https://localhost:7177/story/${story.id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(story),
    });
    if (!res.ok) {
        const errorData = await res.json();
        throw new Error(JSON.stringify(errorData));
    }
    return await res.json();
}

export function EditStory(props: EditStoryProps) {
    const [story, setStory] = useState<Story>({ id: -1, title: 'BadResponse', collectionId: -1 });
    const [userLibrary, setUserLibrary] = useState<User>(props.user);
    const [selectedCollection, setSelectedCollection] = useState<number>(-1);
    const [selectedStory, setSelectedStory] = useState<number>(props.storyId ?? -1);

    useEffect(() => {
        fetchUserLibrary(props.user.id).then(collections => setUserLibrary(collections));
    }, [])

    useEffect(() => {
        fetchStoryAsync(selectedStory).then(story => setStory(story));
    }, [selectedStory]);

    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        try {
            await updateStoryAsync(
                {
                    id: story.id,
                    title: story.title,
                    description: story.description,
                    imageUrl: story.imageUrl,
                    tags: story.tags,
                    collectionId: story.collectionId,
                    pages: story.pages
                }
            );

            props.closeComponent();
            // Navigate after successful parsing
            // console.log('Navigating to /pitch/', id);
            // navigate(`/pitch/${id}`);
        } catch (error: any) {
            if (error.message) {
                console.log(error.message);
                return;
            }
        }
    };


    //Dynamic change handler
    const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        setStory({
            ...story,
            [e.target.name]: e.target.value
        })
    }

    const handleCollectionChange = (e: ChangeEvent<HTMLSelectElement>) => {
        setSelectedCollection(parseInt(e.target.value)); // Parse value to integer
    }

    return <>
        <div className="card">
            <div>
                <h2>Edit Story</h2>
                {selectedStory === -1 && <>
                    <form>
                        <select value={selectedCollection} id='collection' name='collectionId' onChange={handleCollectionChange}>
                            {userLibrary.collections && userLibrary.collections.length > 0 && <>
                                <option value={-1}>Choose Collection</option>
                                {userLibrary.collections.map(collection => (
                                    <option value={collection.id} key={collection.id}>{collection.name}</option>
                                ))}
                            </>}
                            {userLibrary.collections && userLibrary.collections.length === 0 && <option value={-1}>None</option>}
                        </select>
                    </form>

                    {selectedCollection !== -1 && <>
                        <form>
                            <select value={selectedStory} id='story' name='storyId' onChange={(e) => setSelectedStory(parseInt(e.target.value))}>
                                {userLibrary.collections && userLibrary.collections.length > 0 && (
                                    <>
                                        <option value={-1}>Choose Story</option>
                                        {(userLibrary.collections.find(collection => collection.id === selectedCollection)?.stories ?? []).map(story => (
                                            <option value={story.id} key={story.id}>{story.title}</option>
                                        ))}
                                    </>
                                )}
                                {userLibrary.collections && userLibrary.collections.length === 0 && <option value={-1}>None</option>}
                            </select>
                        </form>
                    </>}
                </>}

                {selectedStory !== -1 &&
                    <form onSubmit={handleSubmit}>
                        <input placeholder="Title" value={story.title} id='title' name='title' type='text' onChange={handleChange} />
                        <input placeholder="Description" value={story.description ? story.description : ''} id='description' name='description' type='text' onChange={handleChange} />
                        <select value={story.collectionId} id='collection' name='collectionId' onChange={handleChange}>
                            {userLibrary.collections && userLibrary.collections.length > 0 && <>
                                <option value={''}>Choose Collection</option>
                                {userLibrary.collections.map(collection => (
                                    <option value={collection.id} key={collection.id}>{collection.name}</option>
                                ))}
                            </>}
                            {userLibrary.collections && userLibrary.collections.length === 0 && <option value={-1}>None</option>}
                        </select>
                        <h2>Pages</h2>
                        <p>Add page component here</p>
                        <button type="submit">Submit</button>
                    </form>
                }
            </div>
        </div>
    </>
}