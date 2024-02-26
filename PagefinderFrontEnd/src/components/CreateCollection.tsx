import { Dispatch, FormEvent, SetStateAction, useState } from "react";

async function createCollection(
    name: string,
    description: string,
    imageUrl: string,
    userId: number | undefined
): Promise<Collection> {

    if (userId === undefined) {
        throw new Error("User ID not defined.");
    }
    else {
        const res = await fetch(
            `https://localhost:7177/collection`,
            {
                method: 'POST',
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    name,
                    description,
                    imageUrl,
                    userId
                })
            });

        if (!res.ok) {
            const errorData = await res.json();
            throw new Error(JSON.stringify(errorData));
        }

        const createdCollection = await res.json();
        return createdCollection;
    }
}

type CreateCollectionProps = {
    userId: number | undefined;
    editCollection: (collectionId: number)=> void;
}

export function CreateCollection(props: CreateCollectionProps) {
    const [name, setName] = useState<string>('');
    const [description, setDescription] = useState<string>('');
    const [imageUrl, setImageUrl] = useState<string>('');

    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            const createdStory = await createCollection(
                name,
                description,
                imageUrl,
                props.userId
            );
            //   props.addStory(createdStory);
            //   navigate(`/pitch/${createdStory.id}`);

            props.editCollection(createdStory.id);

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
                <h2>Create Collection</h2>
                <form onSubmit={handleSubmit}>
                    <input placeholder="Name" id='name' name='name' type='text' onChange={(e) => setName(e.target.value)} />
                    <input placeholder="Description" id='description' name='description' type='text' onChange={(e) => setDescription(e.target.value)} />
                    <button type="submit">Submit</button>
                </form>
            </div>
        </div>
    </>
}