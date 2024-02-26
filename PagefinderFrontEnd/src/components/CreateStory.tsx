import { Dispatch, FormEvent, SetStateAction, useEffect, useState } from "react";

async function createStory(
    title: string,
    description: string,
    imageUrl: string,
    tags: string,
    collectionId: number
): Promise<Story> {

    const res = await fetch(
        `https://localhost:7177/story`,
        {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                title,
                description,
                imageUrl,
                tags,
                collectionId
            })
        });

    if (!res.ok) {
        const errorData = await res.json();
        throw new Error(JSON.stringify(errorData));
    }

    const createdStory = await res.json();
    return createdStory;
}

async function fetchCollectionsAsync(id: number | undefined): Promise<Collection[]> {
    const response = await fetch(`https://localhost:7177/User/${id}/collections/`);

    try {
        const resObject = await response.json();

        console.log(resObject);

        return resObject;
    }
    catch (error) {
        console.log(error);
        return [];
    }
}

type CreateStoryProps = {
    userId: number | undefined;
    editStory: ()=> void;
    setEditStoryId: Dispatch<SetStateAction<number | null>>;
    // addStory: (story: Story) => void;
}

export function CreateStory(props: CreateStoryProps) {
    const [collections, setCollections] = useState<Collection[]>([]);
    const [title, setTitle] = useState<string>('');
    const [description, setDescription] = useState<string>('');
    const [imageUrl, setImageUrl] = useState<string>('');
    const [tags, setTags] = useState<string>('');
    const [collectionId, setCollectionId] = useState<string>('');

    useEffect(() => {
        fetchCollectionsAsync(props.userId).then(collections => setCollections(collections));
    }, [])

    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            const createdStory = await createStory(
                title,
                description,
                imageUrl,
                tags,
                parseInt(collectionId)
            );
            //   props.addStory(createdStory);
            //   navigate(`/pitch/${createdStory.id}`);
            props.setEditStoryId(createdStory.id);
            props.editStory();

        } catch (error: any) {
            if (error.message) {
                const errorData = JSON.parse(error.message);
                if (errorData.errors) {
                    const errorMessages = Object.values(errorData.errors).flat();
                    console.log(errorMessages.join(' '));
                    return;
                }
            }
            console.log('An unexpected error occurred.');
        }
    };

    return <>
        <div className="card">
            <div>
                <h2>Create Story</h2>
                <form onSubmit={handleSubmit}>
                    <input placeholder="Title" id='title' name='title' type='text' onChange={(e) => setTitle(e.target.value)} />
                    <input placeholder="Description" id='description' name='description' type='text' onChange={(e) => setDescription(e.target.value)} />
                    <input placeholder="fantasy, romance, comedy" id='tags' name='tags' type='text' onChange={(e) => setTags(e.target.value)} />
                    <select name='collection' id='collection' onChange={(e) => setCollectionId(e.target.value)}>
                        {collections.length > 0 && <>
                            <option value={''}>Choose Collection</option>
                            {collections.map(collection => (
                                <option value={collection.id} key={collection.id}>{collection.name}</option>
                            ))}
                        </>}
                        {collections.length === 0 && <option value={-1}>None</option>}
                    </select>
                    <button type="submit">Submit</button>
                </form>
            </div>
        </div>
    </>
}