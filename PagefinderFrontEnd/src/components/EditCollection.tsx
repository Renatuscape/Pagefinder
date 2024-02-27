import { ChangeEvent, FormEvent, useEffect, useState } from "react";
import { StoryRow } from "./StoryRow";

type EditCollectionProps = {
    user: User;
    collectionId: number | null;
    closeComponent: () => void;
    updateCollectionInUser: (updatedCollection: Collection) => void;
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

async function updateCollectionAsync(
    collection: Collection
): Promise<Collection> {
    const res = await fetch(`https://localhost:7177/collection/${collection.id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(collection),
    });
    if (!res.ok) {
        const errorData = await res.json();
        throw new Error(JSON.stringify(errorData));
    }
    return await res.json();
}

export function EditCollection(props: EditCollectionProps) {
    const [collection, setCollection] = useState<Collection>({ id: -1, name: 'Bad Request', userId: -1 });
    const [userLibrary, setUserLibrary] = useState<User>(props.user);
    const [selectedCollection, setSelectedCollection] = useState<number>(-1);

    useEffect(() => {
        fetchUserLibrary(props.user.id).then(collections => setUserLibrary(collections));
    }, [])

    useEffect(() => {
        setCollection(userLibrary.collections?.find(collection => collection.id === selectedCollection) ?? { id: -1, name: 'Bad Request', userId: -1 });
    }, [selectedCollection]);

    const handleCollectionChange = (e: ChangeEvent<HTMLSelectElement>) => {
        setSelectedCollection(parseInt(e.target.value)); // Parse value to integer
    }

    //Dynamic change handler
    const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        setCollection({
            ...collection,
            [e.target.name]: e.target.value
        })
    }

    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        try {
            const updatedCollection = await updateCollectionAsync(
                {
                    id: collection.id,
                    name: collection.name,
                    description: collection.description,
                    userId: collection.userId
                }
            );

            props.updateCollectionInUser(updatedCollection);
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

    return <>
        <div className="card">
            <div>
                <h2>Edit Collection</h2>
                {selectedCollection === -1 && <>
                    <form>
                        <select value={selectedCollection} id='collection' name='collectionId' onChange={handleCollectionChange}>
                            {userLibrary.collections && userLibrary.collections.length > 0 && <>
                                <option value={-1}>Choose Collection</option>
                                {userLibrary.collections.map(collection => (
                                    <option value={collection.id} key={'collection' + collection.id}>{collection.name}</option>
                                ))}
                            </>}
                            {userLibrary.collections && userLibrary.collections.length === 0 && <option value={-1}>None</option>}
                        </select>
                    </form></>}

                {selectedCollection !== -1 && <>
                    <form onSubmit={handleSubmit}>
                        <input placeholder="Name" value={collection.name} id='name' name='name' type='text' onChange={handleChange} />
                        <input placeholder="Description" value={collection.description ? collection.description : ''} id='description' name='description' type='text' onChange={handleChange} />
                        <button type="submit">Submit</button>
                    </form>
                    <h2>Stories</h2>
                    <p>Deleting stories is irreversible.</p>
                    {collection.stories?.map(story => (
                        <StoryRow key={'story' + story.id} story={story} allowDelete={true} />
                    ))}
                </>
                }
            </div>
        </div>
    </>
}