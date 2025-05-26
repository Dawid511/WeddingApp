import { Photo } from "./photo"

export interface Member {
    id: number
    title: string
    price: number
    photoUrl: string
    introduction: string
    city: string
    photos: Photo[]
}

