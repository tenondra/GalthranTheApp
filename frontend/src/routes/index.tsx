import {lazy, Suspense} from 'react'
import {BrowserRouter, Route, Routes} from 'react-router-dom'
import {Flex} from "@chakra-ui/react";
import Loading from "../components/Loading.tsx";

const Home = lazy(() => import('../pages/Home'))

export default function Router() {
	return (
		<BrowserRouter>
			<Suspense
				fallback={
					<Flex minH="100vh" alignItems="center" justify="center">
						<Loading/>
					</Flex>
				}
			>
				<Routes>
					<Route path="/" element={<Home/>}/>
				</Routes>
			</Suspense>
		</BrowserRouter>
	)
}