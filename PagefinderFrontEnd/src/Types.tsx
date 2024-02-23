type User = {
    id: number;
    username: string;
    email: string;
    password: string;
    collections?: Collection[] | null;
}

type Collection = {
    id: number;
    name: string;
    description?: string | null;
    imageUrl?: string | null;
    userId: number;
    user?: User | null;
    stories?: Story[] | null;
}

type Story = {
    id: number;
    title: string;
    description?: string | null;
    tags?: string | null;
    imageUrl?: string | null;
    collectionId: number;
    collection?: Collection | null;
    pages?: Page[] | null;
}

type Page = {
    id: number;
    storyId: number;
    order: number;
    pageTitle?: string | null;
    pageText?: string | null;
    imageUrl?: string | null;
    isEnd: boolean;
    story?: Story | null;
    choices?: Choice[] | null;
}

type Choice = {
    id: number;
    successPageId: number;
    failurePageId: number;
    text?: string | null;
    successPage?: Page | null;
    failurePage?: Page | null;
}