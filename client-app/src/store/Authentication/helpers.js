import {mapGetters} from 'vuex'
import {mapState} from 'vuex'

export const authenticatedComputed = {
    ...mapGetters(['loggedIn'])
}

export const displayNameComputed = {
    ...mapGetters(['loggedInUser'])
}

export const loadingComputed = {
    ...mapGetters(['isLoading'])
}

export const usernameComputed = {
    ...mapGetters(['loggedInUserName'])
}

export const baseURL = {
    ...mapState(['$localAPI'])
}